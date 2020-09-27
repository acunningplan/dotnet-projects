import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Blog } from "src/app/models/blog";
import { BlogService } from "src/app/services/blog.service";

@Component({
  selector: "app-delete-modal",
  templateUrl: "./delete-modal.component.html",
  styleUrls: ["./delete-modal.component.css"],
})
export class DeleteModalComponent implements OnInit {
  @Input() blog: Blog;

  constructor(private blogService: BlogService, private router: Router) {}

  ngOnInit() {}

  onDelete() {
    this.blogService
      .deleteBlog(this.blog.id)
      .subscribe((res) => this.router.navigate(["/profile"]));
  }
}
