﻿using System.Collections.Generic;
using _0_Framework.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Website { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public Guid OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public Guid ParentId { get; private set; }
        public Comment Parent { get; private set; }
        public ICollection<Comment> Replies { get; private set; } = new List<Comment>();

        public Comment(string name, string email, string website, string message, Guid ownerRecordId, int type, Guid parentId)
        {
            Name = name;
            Email = email;
            Website = website;
            Message = message;
            OwnerRecordId = ownerRecordId;
            Type = type;
            ParentId = parentId;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
