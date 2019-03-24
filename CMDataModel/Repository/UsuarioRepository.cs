﻿using System.Data.Entity;
using CMDataModel.Repository.Base;
using CMDataModel.Repository.Interfaces;

namespace CMDataModel.Repository
{
    public class UsuarioRepository : Repository<Usuario, CMDataEntities>, IUsuarioRepository
    {
        public UsuarioRepository(DbContext context) : base(context)
        {
        }
    }
}
