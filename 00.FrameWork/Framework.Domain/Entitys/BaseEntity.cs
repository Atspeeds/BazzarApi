﻿using Framework.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain.Entitys
{
    public abstract class BaseEntity<TId> where TId : IEquatable<TId>
    {
        
        public TId Id { get; protected set; }
      
        protected BaseEntity() { }

        private readonly List<IEvent> _events = new List<IEvent>();
        protected void Raise(IEvent @event) => _events.Add(@event);
        protected abstract void SetStateByEvent(IEvent @event);
        protected abstract void ValidateInvariants();
        protected void HandleEvent(IEvent @event)
        {
            SetStateByEvent(@event);
            ValidateInvariants();
            Raise(@event);
        }
        public IEnumerable<IEvent> GetChanges() => _events.AsEnumerable();
        public void ClearChanges() => _events.Clear();
        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity<TId>;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            //if (Id == default || other.Id == default)
            //    return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity<TId> a, BaseEntity<TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }


    }
}