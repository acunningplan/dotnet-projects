import { Blog } from "./blog";

export class Profile {
  displayName = "Guest";
  bio = "";
  blogs: Blog[] = [];
  username = "";
  email = "";
  lastLogin: Date;
  profilePicture = new UserPhoto();
  following = false;
  followers: Follower[];
  followings: Following[];
}

class Follower {
  followingUser: string;
}

class Following {
  followedUser: string;
}

class UserPhoto {
  url: string;
  id: string;
}
