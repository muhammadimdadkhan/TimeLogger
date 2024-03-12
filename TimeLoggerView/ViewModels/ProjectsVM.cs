using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeLoggerView.Models;

namespace TimeLoggerView.ViewModels
{
    class ProjectsVM : ViewModelBase
    {

        private readonly PageModel _pageModel;

        public readonly IProjectService _ProjectService;

        public ProjectsVM(IProjectService ProjectService)
        {
            _ProjectService = ProjectService;
            _pageModel = new PageModel();

        }
        public ProjectsVM()
        {

            _ProjectService = ((App)Application.Current).ServiceProvider.GetService<IProjectService>();
            _pageModel = new PageModel();
        }
    }
}
