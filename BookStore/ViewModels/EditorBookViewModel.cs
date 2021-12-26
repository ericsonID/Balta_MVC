using BookStore.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.ViewModels
{
    public class EditorBookViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome Inválido")]
        [Display(Name = "Nome do livro")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "IsBN Inválido")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Data Inválida")]
        [Display(Name ="Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }
        [Required(ErrorMessage = "Selecione uma Categoria")]
        [Display(Name ="Categoria")]
        public int CategoriaId { get; set; }
        public SelectList CategoriaOptions { get; set; }
        [CheckAgeValidator]
        public DateTime Age { get; set; }

    }
}