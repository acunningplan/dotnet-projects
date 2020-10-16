import { Profile } from "./profile";
import { Photo } from "./image";
import { BlogComment } from "./comment";

export class Blog {
  id: string;
  user: Profile;
  images: Photo[];
  title = "";
  description = "";
  coordinates = "51.45395348950013,-0.9786673543780711";
  created: Date;
  date = "";
  comments: BlogComment[];
}
