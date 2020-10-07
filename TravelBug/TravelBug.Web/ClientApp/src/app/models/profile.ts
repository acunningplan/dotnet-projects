export class Profile {
  displayName = "Guest";
  bio = "";
  username = "";
  email = "";
  profilePicture = new UserPhoto();
  following = false;
  followers: Follower[];
}

class Follower {
  followingUser: string;
}

class UserPhoto {
  url: string;
  id: string;
}
