namespace Presentation;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Merchants
    {
        private const string Base = $"{ApiBase}/merchants";
        public const string Create = Base;
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
    
    public static class Categories
    {
        private const string Base = $"{ApiBase}/categories";
        public const string GetAll = Base;
    }
}