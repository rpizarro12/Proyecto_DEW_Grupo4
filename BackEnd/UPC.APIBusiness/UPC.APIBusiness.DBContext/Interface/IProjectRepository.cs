using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    //2
    public interface IProjectRepository
    {
        List<EntityProject> GetProjects();

        EntityProject GetProject(int id);
    }
}
