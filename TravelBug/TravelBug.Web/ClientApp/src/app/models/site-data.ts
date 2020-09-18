import { Blog } from "./blog";
import { Profile } from "./profile";

export class SiteData {
  constructor(blogs: Blog[]) {
    this.blogs = blogs;
  }
  blogs: Blog[];
  profile: Profile
}
