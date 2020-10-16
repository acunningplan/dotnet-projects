import { Profile } from "./profile";

export class BlogComment {
  id: string;
  // title = "";
  description = "";
  author: Profile;
  created: Date;
}
