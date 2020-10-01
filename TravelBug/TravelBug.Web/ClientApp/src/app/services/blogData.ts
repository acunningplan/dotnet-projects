import { Blog } from "../models/blog";

export class BlogData {
  // The blog (with title and description)
  blog: Blog;
  // Photo url's (imgur url or data url, depending on whether the photos are uploaded)
  photos: (string | ArrayBuffer)[];
  // Photo files (to be uploaded)
  files?: File[];
}
