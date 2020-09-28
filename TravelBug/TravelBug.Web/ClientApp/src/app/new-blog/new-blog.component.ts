import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Component, OnDestroy, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { environment } from "src/environments/environment";
import { Blog } from "../models/blog";
import { Image } from "../models/image";
import { BlogService } from "../services/blog.service";
import { PhotoService } from "../services/photo.service";
import { RouterTrackingService } from "../services/router-tracking.service";
import { ImageUploadResponse } from "./image-upload-response";
import { PostBlogResponse } from "./post-blog-response";

@Component({
  selector: "app-new-blog",
  templateUrl: "./new-blog.component.html",
  styleUrls: ["./new-blog.component.css"],
})
export class NewBlogComponent implements OnInit, OnDestroy {
  blog: Blog;
  photos: (string | ArrayBuffer)[] = [];
  files: File[] = [];
  warning: string = null;
  backToLink = "/";

  // uploadForm: FormGroup

  // Whether this is new blog or edited blog
  // Only allowed to edit blog if user is author
  newBlog = true;

  constructor(
    private blogService: BlogService,
    private photoService: PhotoService,
    // private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private routerTrackingService: RouterTrackingService,
    private http: HttpClient
  ) {}

  ngOnInit() {
    let segment = this.activatedRoute.snapshot.url[0].path;
    console.log(segment);
    this.newBlog = segment === "new-blog";

    if (this.newBlog) {
      this.blog = this.blogService.loadCurrentBlog();
    } else {
      this.blog = this.blogService.loadEditedBlog();
    }
    // if (!this.update) this.blog = this.blogService.loadCurrentBlog();
    // else this.blog = new Blog();
    this.backToLink = this.routerTrackingService.prevUrl;

    // this.uploadForm = this.formBuilder.group({
    //   photos: ['']
    // });
  }

  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
      let file = <File>event.target.files[0];
      this.files.push(file);

      var reader = new FileReader();
      reader.readAsDataURL(file); // read file as data url
      reader.onload = (pe: ProgressEvent) => {
        // called once readAsDataURL is completed
        this.photos.push(reader.result);
      };
    }
  }

  onUpload() {
    let fd = new FormData();
    this.files.forEach((file) => fd.append("file", file, file.name));

    for (var key of fd.entries()) {
      console.log(key[1]);
    }

    // Post blog without images
    this.http.post(`${environment.apiUrl}/blog`, this.blog).subscribe(
      (res: PostBlogResponse) => {
        console.log("Uploading images");
        let blogId = res.id;
        // Upload images to imgur, then save image url's to blog

        // Test imgur
        // this.http
        //   .post("https://api.imgur.com/3/upload", fd, {
        //     headers: new HttpHeaders({
        //       Authorization:
        //         "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJlZCIsIm5iZiI6MTYwMTI4NzE3MCwiZXhwIjoxNjAxODkxOTcwLCJpYXQiOjE2MDEyODcxNzB9.3FzAtCvi-V1gNXJw3lERi-yuM6M1UKtUt913sFkvYUpR4wuxrfXBFE4JnqFlDbU3HKjXdtmBRTLe59qmTZfdbQ",
        //     }),
        //   })
        //   .subscribe((res) => console.log(res));

        this.http.post(`${environment.apiUrl}/photo/${blogId}`, fd).subscribe(
          (res: ImageUploadResponse) => {
            // this.router.navigate(["/"]);
          },
          // Log error if image upload fails
          (err) => console.log(err)
        );
      },
      // Log error if blog post fails
      (err) => console.log(err)
    );
  }

  onSubmit(title: NgForm, description: NgForm) {
    // console.log(this.blog);
    // console.log(title.value, description.value);
    if (!title.value || !description.value) {
      this.warning = "Title and description must be non-empty.";
    } else if (this.newBlog) {
      this.blogService.postBlog(this.blog).subscribe(() => {
        // this.photoService.uploadImages();
        this.backToHome();
      });
    } else {
      this.blogService.patchBlog(this.blog).subscribe(() => this.backToHome());
    }
  }

  private backToHome() {
    // Reset blog and navigate to home
    this.blog = new Blog();
    this.router.navigate(["/profile"]);
  }

  ngOnDestroy() {
    // Save the current blog
    if (this.newBlog) this.blogService.saveCurrentBlog(this.blog);
  }
}
