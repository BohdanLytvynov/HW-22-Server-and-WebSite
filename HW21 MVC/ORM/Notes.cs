using System;
using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Notes
    {
        [Required]
        public Guid Id { get; set; }//Id of a Note

        [Required]
        [MaxLength(20)]
        public string Surename { get; set; }//Surename

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }//Name

        [Required]
        [MaxLength(20)]
        public string Lastname { get; set; }//Lastname

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }//Phone

        [Required]
        [MaxLength(200)]
        public string Adress { get; set; }//Adress

        [Required]
        [MaxLength(3000)]
        public string Description { get; set; }//Description

        //Empty ctor
        public Notes()
        {

        }

        //Ctor with arguments
        public Notes(Guid id, string surename, string name, string lastname,
            string phone, string adress, string description)
        {
            this.Id = id;
            this.Surename = surename;
            this.Name = name;
            this.Lastname = lastname;
            this.Phone = phone;
            this.Adress = adress;
            this.Description = description;
        }

        /// <summary>
        /// Sets new value to a note in db
        /// </summary>
        /// <param name="note"></param>
        public void SetNewValues(Notes note)
        {
            this.Surename = note.Surename;
            this.Name = note.Name;
            this.Lastname = note.Lastname;
            this.Phone = note.Phone;
            this.Adress = note.Adress;
            this.Description = note.Description;
        }
    }
}
