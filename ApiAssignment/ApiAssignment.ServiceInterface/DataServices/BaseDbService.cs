using ApiAssignment.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApiAssignment.ServiceInterface
{
    public class BaseDbService<T> where T : BaseEntity
    {
        public readonly IMongoCollection<T> _collection;

        public BaseDbService(IMongoDatabase db)
        {
            var collectionName = (CollectionNameAttribute[])Attribute.GetCustomAttributes(typeof(T), typeof(CollectionNameAttribute));
            if (string.IsNullOrEmpty(collectionName?.FirstOrDefault()?.Name))
            {
                throw new Exception("Invalid collection name, please add alias name on model");
            }
            _collection = db.GetCollection<T>(collectionName?.FirstOrDefault()?.Name ?? string.Empty);
        }

        public List<T> GetAll()
        {
            return _collection.Find(book => true).ToList();
        }

        public T Get(string id)
        {
            return _collection.Find(book => book.Id == id).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> expressions)
        {
            return _collection.Find<T>(expressions).FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expressions)
        {
            return _collection.Find<T>(expressions).ToList();
        }

        public T Create(T book)
        {
            _collection.InsertOne(book);
            return book;
        }

        public void Update(string id, T bookIn) =>
            _collection.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Car bookIn) =>
            _collection.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _collection.DeleteOne(book => book.Id == id);
    }
}