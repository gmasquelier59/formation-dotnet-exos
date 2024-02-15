﻿using Exercice03_PizzeriaOnLine.Models;

namespace Exercice03_PizzeriaOnLine.Services;

public interface IPizzaService
{
    public List<Pizza> GetAll();

    public void Add(Pizza pizza);

    public List<Ingredient> GetAllIngredients();

    public Dictionary<int, string> GetAllIngredientsIds();
}
