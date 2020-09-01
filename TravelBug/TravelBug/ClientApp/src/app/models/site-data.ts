import { Blog } from "../blogs/blog";

export class SiteData {
  constructor(blogs: Blog[]) {
    this.blogs = blogs;
  }
  blogs: Blog[];
  profile: Profile
}
