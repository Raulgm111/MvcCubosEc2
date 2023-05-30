﻿using Microsoft.EntityFrameworkCore;
using MvcCubosEc2.Data;
using MvcCubosEc2.Models;

namespace MvcCubosEc2.Repositories
{
    public class RepositoryCubos
    {

        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }

        public async Task<Cubo> FindCuboAsync(int id)
        {
            return await
                this.context.Cubos
                .FirstOrDefaultAsync(x => x.IdCubo == id);
        }

        private int GetMaxIdCubo()
        {
            return this.context.Cubos.Max(x => x.IdCubo) + 1;
        }

        public async Task CreateCuboAsync(string nombre, string marca,string imagen, int precio)
        {
            Cubo cubo = new Cubo();
            cubo.IdCubo = this.GetMaxIdCubo();
            cubo.Nombre = nombre;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            this.context.Cubos.Add(cubo);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateCuboAsync(int id, string nombre, string marca, string imagen, int precio)
        {
            Cubo cubo = await this.context.Cubos.FindAsync(id);

            if (cubo != null)
            {
                cubo.Nombre = nombre;
                cubo.Marca = marca;
                cubo.Imagen = imagen;
                cubo.Precio = precio;

                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteCuboAsync(int id)
        {
            Cubo cubo = await this.context.Cubos.FindAsync(id);

            if (cubo != null)
            {
                this.context.Cubos.Remove(cubo);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
