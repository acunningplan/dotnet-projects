import { Profile } from "./profile";

export class BlogComment {
  constructor(profile?: Profile) {
    this.author = profile;
  }
  id: string;
  blogId: string;
  // title = "";
  description = "";
  author: Profile;
  created: Date;
}
