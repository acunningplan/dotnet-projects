import {
  AuthServiceConfig,
  FacebookLoginProvider,
  GoogleLoginProvider,
} from "angularx-social-login";
import { environment } from "src/environments/environment";

const config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider(environment.googleClientId),
  },
  {
    id: FacebookLoginProvider.PROVIDER_ID,
    provider: new FacebookLoginProvider(environment.fbClientId),
  },
]);

export function provideConfig() {
  return config;
}
