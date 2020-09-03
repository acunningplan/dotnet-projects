export interface Profile {
  name: string;
  email: string;
  imageUrl: string;
}

export class FacebookProfile {

}


export class GoogleProfile implements Profile {
  email: string;
  imageUrl: string;
  name: string;
  givenName: string;

  constructor(profile: gapi.auth2.BasicProfile) {
    this.name = profile.getName();
    this.email = profile.getEmail();
    this.imageUrl = profile.getImageUrl();
    this.givenName = profile.getGivenName();
  }
}
