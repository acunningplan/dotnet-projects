export class Profile {
  displayName = "Guest";
  bio = ""
  username = "";
  email = "";
  photoUrl = "";
  following = false;
  followers: Follower[];
}

class Follower {
  followingUser: string;
}
