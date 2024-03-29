﻿using Commons.Entities;
using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoListWPF.Services
{
    public static class OpenUWPViews
    {
        public static void ShowAddNewTaskView(TaskEntity taskEntity)
        {

            Process.Start($"com.todolistuwp://Params?Page={EnumViewNames.AddNewTaskPage}&Id={taskEntity.Id}");


        }

        public static void ShowAddNewTaskView()
        {
            Process.Start($"com.todolistuwp://Params?Page={EnumViewNames.AddNewTaskPage}");


        }

        public static void ShowPresentationsOfAllTasksView()
        {
            Process.Start($"com.todolistuwp://Params?Page={EnumViewNames.PresentationOfAllTasksView}");
        }
    }
}
