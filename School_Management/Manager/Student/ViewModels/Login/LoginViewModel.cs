﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using School_Management.Manager.Student.StudentEntitiesDataModel;
using School_Management.Manager.Student.Common;
using School_Management.Manager.Student;

namespace School_Management.Manager.Student.ViewModels {

    /// <summary>
    /// Represents the single Login object view model.
    /// </summary>
    public partial class LoginViewModel : SingleObjectViewModel<Login, string, IStudentEntitiesUnitOfWork> {

        /// <summary>
        /// Creates a new instance of LoginViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static LoginViewModel Create(IUnitOfWorkFactory<IStudentEntitiesUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new LoginViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the LoginViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected LoginViewModel(IUnitOfWorkFactory<IStudentEntitiesUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Logins, x => x.Username) {
                }



    }
}
