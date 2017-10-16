﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SoT.Domain.Entities.Example;
using SoT.Domain.Interfaces.Repository;
using System.Linq;

namespace SoT.Domain.Tests.Mock
{
    public class ExampleRepositoryMock : IExampleRepository
    {
        public void Add(Example obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Example> Find(Expression<Func<Example, bool>> predicate)
        {
            return new List<Example>
            {
                new Example
                {
                    ExampleId = Guid.Parse("6a248df2-0906-40f8-a9f2-2f3907e7165e")
                }
            };
        }

        public IEnumerable<Example> GetActive()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Example> GetAll()
        {
            var example01 = new Example
            {
                Name = "John Doe",
                DatePropertyName = DateTime.Now,
                SubExamples = new List<SubExample>()
            };
            
            var subExample01 = new SubExample
            {
                StringPropertyName = "Test text",
                SubExampleDatePropertyName = DateTime.Now,
                ExampleId = example01.ExampleId
            };

            example01.SubExamples.ToList().Add(subExample01);

            var example02 = new Example
            {
                Name = "John Doe II",
                DatePropertyName = DateTime.Now,
                SubExamples = new List<SubExample>()
            };

            var subExample02 = new SubExample
            {
                StringPropertyName = "Test text 2",
                SubExampleDatePropertyName = DateTime.Now,
                ExampleId = example02.ExampleId
            };

            example02.SubExamples.ToList().Add(subExample02);

            return new List<Example>
            {
                example01,
                example02
            };
        }

        public Example GetById(Guid id)
        {
            var example = new Example
            {
                Name = "John Doe",
                DatePropertyName = DateTime.Now,
                SubExamples = new List<SubExample>()
            };

            example.ExampleId = Guid.Parse("6a248df2-0906-40f8-a9f2-2f3907e7165e");

            var subExample = new SubExample
            {
                StringPropertyName = "Test text",
                SubExampleDatePropertyName = DateTime.Now,
                ExampleId = example.ExampleId
            };

            example.SubExamples.ToList().Add(subExample);

            return example;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Example obj)
        {
            throw new NotImplementedException();
        }
    }
}
