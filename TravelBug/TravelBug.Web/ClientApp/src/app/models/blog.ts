import { Profile } from "./profile";
import {Photo} from "./image"

export class Blog {
  id: string;
  user: Profile;
  images: Photo[];
  title = "";
  description = "";
  location = "";
  created = "";
  date = "";
}
