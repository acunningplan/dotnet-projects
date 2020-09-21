import { Profile } from "./profile";
import {Image} from "./image"

export class Blog {
  id: string;
  user: Profile;
  images: Image[];
  title = "";
  description = "";
  location = "";
  created = "";
  date = "";
}
