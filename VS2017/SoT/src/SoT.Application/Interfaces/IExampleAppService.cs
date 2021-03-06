﻿using SoT.Application.Validation;
using SoT.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace SoT.Application.Interfaces
{
    public interface IExampleAppService : IDisposable
    {
        IEnumerable<ExampleViewModel> GetActive();

        // TODO: paging should be added to method.
        IEnumerable<ExampleViewModel> GetAll();

        ExampleViewModel GetById(Guid id);

        ValidationAppResult Add(ExampleSubExampleViewModel exampleSubExampleViewModel);

        void Update(ExampleViewModel exampleViewModel);

        void Remove(Guid id);
    }
}
