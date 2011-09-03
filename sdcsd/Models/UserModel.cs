/***********************************************************************
 * Copyright (C) 2011 Ari Rokosa, Chinedu Eze, Johannes Virtanen,
 *                    Petri Tuononen, Timo Korkalainen
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace sdcsd.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime LastSeen { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public DbSet<UserModel> UsersDB { get; set; }
    }
}