import { NgcCookieConsentConfig} from 'ngx-cookieconsent';
import { environment } from 'src/environments/environment';


export const cookieConfig: NgcCookieConsentConfig = {
  cookie: {
    domain: environment.domain // or 'your.domain.com' // it is mandatory to set a domain, for cookies to work properly (see https://goo.gl/S2Hy2A)
  },
  palette: {
    popup: {
      background: '#000'
    },
    button: {
      background: '#f1d600'
    }
  },
  theme: 'edgeless',
  type: 'opt-out'
};
