export class Endpoints{
    public static readonly BYTRAVELLER = class BytravellerEndpoints{
        public static readonly URL = 'http://localhost/ByTravellerAPI/api';
        public static readonly SIGNIN = `${BytravellerEndpoints.URL}/Login/SignIn`;
        public static readonly SIGNUP = `${BytravellerEndpoints.URL}/Login/SignUp`;
    }
}