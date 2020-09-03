import { Blog } from "../blogs/blog";
import { Profile } from "./profiles";

export class SiteData {
  constructor(blogs: Blog[]) {
    this.blogs = blogs;
  }
  blogs: Blog[];
  profile: Profile
}
