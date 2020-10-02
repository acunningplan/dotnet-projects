import { Blog } from "./blog";
import { Photo } from "./image";

export class BlogData {
  // The blog (with title and description)
  blog: Blog = new Blog();

  // Photos to upload (data url's, stored in browser)
  photosToUpload: (string | ArrayBuffer)[] = [];
  // Photo files (to be uploaded)
  files: File[] = [];

  // Existing photos in a blog (imgur url's, edit mode only)
  photos?: Photo[] = [];
  // Photos to delete (imgur url's, edit mode only)
  photosToDelete?: string[] = [];
}
