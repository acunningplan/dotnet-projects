import { HttpClient } from "@angular/common/http";
import { Component, OnDestroy, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Blog } from "../models/blog";
import { Image } from "../models/image";
import { BlogService } from "../services/blog.service";
import { BlogData } from "../models/blogData";
import { PhotoService } from "../services/photo.service";
import { RouterTrackingService } from "../services/router-tracking.service";
import { ImageUploadResponse } from "./image-upload-response";
import { PostBlogResponse } from "./post-blog-response";

// import { ImageResult, ResizeOptions, } from 'ng2-imageupload';

@Component({
  selector: "app-new-blog",
  templateUrl: "./new-blog.component.html",
  styleUrls: ["./new-blog.component.css"],
})
export class NewBlogComponent implements OnInit, OnDestroy {
  blog: Blog;
  photosToUpload: (string | ArrayBuffer)[] = [];
  files: File[] = [];
  warning: string = null;
  backToLink = "/";

  // Edit blog
  photosToDelete: string[] = [];
  photos: Image[] = [];

  // uploadForm: FormGroup

  // Whether this is new blog or edited blog
  // Only allowed to edit blog if user is author
  newBlog = true;

  constructor(
    private blogService: BlogService,
    private photoService: PhotoService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private routerTrackingService: RouterTrackingService,
    private http: HttpClient
  ) {}

  // resizeOptions: ResizeOptions = {
  //   resizeMaxHeight: 200
  // };

  // selected(imageResult: ImageResult) {
  //     let src = imageResult.resized
  //         && imageResult.resized.dataURL
  //         || imageResult.dataURL;

  //     this.photos.push(src)
  // }

  private loadBlog(blogData: BlogData) {
    let { blog, photos, photosToUpload, files, photosToDelete } = blogData;
    this.blog = blog;
    this.photosToUpload = photosToUpload;
    this.files = files;

    // Edit mode
    if (!this.newBlog) {
      this.photos = photos;
      this.photosToDelete = photosToDelete;
    }
  }

  ngOnInit() {
    // Find out whether this is in new or edit mode
    let segment = this.activatedRoute.snapshot.url[0].path;
    console.log(segment);
    this.newBlog = segment === "new-blog";

    // Get blog
    let blogData = this.newBlog
      ? this.blogService.loadCurrentBlog()
      : this.blogService.loadEditedBlog();

    this.loadBlog(blogData);
    this.backToLink = this.routerTrackingService.prevUrl;
  }

  onSelectFile(event) {
    if (event.target.files && event.target.files[0]) {
      // Add file for upload
      let file = <File>event.target.files[0];
      this.files.push(file);

      // Get data url to display selected image
      var reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = (pe: ProgressEvent) => {
        // var arrayBuffer = reader.result;

        this.photosToUpload.push(reader.result);
      };
    }
  }

  // Cancel photo upload
  onClickDelete(id: number) {
    this.photosToUpload.splice(id, 1);
    this.files.splice(id, 1);
  }

  // Delete existing photos in blog
  onClickDeleteExisting(id: number) {
    // Flag photo for delete
    this.photosToDelete.push(this.photos[id].url);
    this.photos.splice(id, 1);
  }

  onSubmit(title: NgForm, description: NgForm) {
    // First, check the blog has a title and description
    if (!title.value || !description.value) {
      this.warning = "Title and description must be non-empty.";
    } else {
      // Prepare photos for upload
      let fd = new FormData();
      this.files.forEach((file) => fd.append("files", file, file.name));

      if (this.newBlog) {
        // Post blog, redirect to profile page, then upload images
        this.blogService
          .postBlog(this.blog)
          .subscribe((res: PostBlogResponse) => {
            // Go back to home (deletes component!)
            this.photoService
              .uploadImages(res.id, fd)
              .subscribe((res: ImageUploadResponse[]) => console.log(res));
            this.backToHome();
          });
      } else {
        // Edit blog, redirect to profile page, then upload and delete images
        this.blogService.patchBlog(this.blog).subscribe(() => {
          let blogId = this.blog.id;
          this.photoService.uploadImages(blogId, fd).subscribe(() => {
            this.photoService
              .deleteImages(blogId, this.photosToDelete)
              .subscribe();
          });
          this.backToHome();
        });
      }
    }
  }

  private backToHome() {
    // Reset blog and navigate to home
    this.blog = new Blog();
    this.router.navigate([
      "/profile",
      window.localStorage.getItem("travelBug:Username"),
    ]);
  }

  ngOnDestroy() {
    // Save the current blog
    if (this.newBlog)
      this.blogService.saveCurrentBlog({
        blog: this.blog,
        photosToUpload: this.photosToUpload,
        files: this.files,
      });
  }
}
