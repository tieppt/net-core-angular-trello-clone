namespace Trollo.Common.Contracts
{
    public static class ApiRoutes
    {
        public const string RootIndex = "";

        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public const string Protected = "protected";

        public static class Auth
        {
            public const string Index = Base + "/auth";

            public const string Login = Index + "/login";

            public const string Register = Index + "/register";
        }
    }
}