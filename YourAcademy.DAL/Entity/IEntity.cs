﻿namespace YourAcademy.DAL.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
