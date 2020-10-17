import { Profile } from "./profile";

export class BlogComment {
  id: string;
  blogId: string;
  // title = "";
  description = "";
  author: Profile;
  created: Date;
}
