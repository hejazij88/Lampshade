﻿namespace _01_LampshadeQuery.Contacts
{
    public class ProductPictureQueryModel
    {
        public Guid ProductId { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public bool IsRemoved { get; set; }
    }

}
