﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniFb.Models;
using MiniFb.Database;
using Microsoft.AspNet.Identity;

namespace MiniFb.Controllers
{//kitas@gmail.com
    //Labas123+

    [Authorize]
    public class PersonController : Controller
    {
        // GET: Person
        List<PersonModel> people = new List<PersonModel>()
        {
            new PersonModel()
            {
                FullName = "mantulis radze",
                Bio = "is rokiskio kaimo, dvidiasimt miatu",
                Age = 27,
                ImgUrl = "https://www.google.lt/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwi4q6n9i7PSAhWLhiwKHaQTAYwQjRwIBw&url=http%3A%2F%2Fwww.delfi.lt%2Fkrepsinis%2Fherojai%2Ft-pacesas-apie-isvyku-prakeiksma-darome-per-daug-klaidu.d%3Fid%3D70271890&psig=AFQjCNGcMiy4QHXit8_fusFbQbtSvo0CwA&ust=1488381681735161"
            },
            new PersonModel()
            {
                FullName = "alfonsas netavoreikalas",
                Bio = "is marijempolias miesto, vaiku niaturiu",
                Age = 2,
                ImgUrl = "https://www.google.lt/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwit-b-rjLPSAhXEfiwKHU6ADjEQjRwIBw&url=http%3A%2F%2Fwww.sveikuoliai.lt%2Framunas-karbauskis-smegenys-yra-mano-darbo-irankis-kodel-tureciau-jas-zaloti-alkoholiu-nezinau-alkoholio-skonio%2F&bvm=bv.148073327,d.bGg&psig=AFQjCNHAfZdhLb0AwSm11Q1axF0PTBz1VQ&ust=1488381777233585"
            },
        };
       
        public ActionResult Index()
        {
            using (var context = new FacebookContext())
            {
              //  PersonModel person = new Models.PersonModel();
              //  person.FullName = "AAA";
              //  context.Persons.Add(person);
                //context.SaveChanges();

                var identity = Guid.Parse(User.Identity.GetUserId());

                //var currentUser = Session["currentUser"];

                var person = context.Persons.FirstOrDefault(u => u.PersonId == identity);
                if (person == null)
                {
                    person = new Models.PersonModel();
                    person.PersonId = identity;
                    context.Persons.Add(person);
                    context.SaveChanges();
                }
                return View("PersonDetails", person);
            }
        }

  



        public ActionResult List()
        {
            using (var context = new FacebookContext())
            {
                //PersonModel person = new Models.PersonModel();
                //person.FullName = "AAA";
                //context.Persons.Add(person);
                //context.SaveChanges();

                var persons = context.Persons.ToList();
                return View("AddPerson2", persons[0]);
            }
        }

        [HttpPost]
        public ActionResult AddPerson2(PersonModel model)
        {
            using (var context = new FacebookContext())
            {
                var persons = context.Persons.ToList();
                return View("Index", persons);
            }
        }

        public ActionResult PersonModel(Guid Id)
        {
            PersonModel selectedPerson = people.Single(person => person.PersonId == Id);
            return View("~/Views/Person/PersonModel.cshtml", selectedPerson);
        }
    
        public ActionResult Edit()
        {
            using (var context = new FacebookContext())
            {
                var identity = Guid.Parse(User.Identity.GetUserId());

                var person = context.Persons.Where(u => u.PersonId == identity).ToList().First();
                return View("Edit", person);
            }
        }
        [HttpPost]
        public ActionResult Edit(PersonModel model)
        {
            PersonModel person;
            using (var context = new FacebookContext())
            {
                var identity = Guid.Parse(User.Identity.GetUserId());
                
                person = context.Persons.Where(u => u.PersonId == identity).ToList().First();
                


                person.Bio = model.Bio;
                person.FullName = model.FullName;
                person.Age = model.Age;
                person.ImgUrl = model.ImgUrl ;

                context.SaveChanges();
            }

            return View("PersonDetails", person);
        }



    }
}