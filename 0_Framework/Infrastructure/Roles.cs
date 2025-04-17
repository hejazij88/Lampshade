using System;

namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Administrator = "6563ee63-d344-46ea-aa32-eede18ed522a";
        public const string SystemUser = "cab27463-bfae-409b-9394-89a41839e727";
        public const string ContentUploader = "39b86ab8-c234-40bd-9821-0774a12ff297";
        public const string ColleagueUser = "6c528e85-da9d-40ab-b587-e99d017d92c8";
        
        public static string GetRoleBy(Guid id)
        {
            switch (id.ToString())
            {
                case "6563ee63-d344-46ea-aa32-eede18ed522a":
                    return "مدیرسیستم";
                case "39b86ab8-c234-40bd-9821-0774a12ff297":
                    return "محتوا گذار";
                default:
                    return "";
            }
        }
    }
}
