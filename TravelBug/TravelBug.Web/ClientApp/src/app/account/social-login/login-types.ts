export class FbLoginResponse {
  id: string;
  email: string;
  name: string;
  picture: {
    data: {
      url: string;
      width: number;
      height: number;
    };
  };
}

export class UserData {
  accessToken: string;
  id: string;
  email: string;
  username: string;
  photoUrl: string;
}
