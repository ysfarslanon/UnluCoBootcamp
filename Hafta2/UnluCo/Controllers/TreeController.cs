using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Entites;
using UnluCo.Extensions;
using UnluCo.Services.Abstract;

namespace UnluCo.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        private static List<Tree> trees = new List<Tree>()
        {
            new Tree{ID=1,Age=2,Name="Kızılçam",Note="Akdeniz ikliminin müşir türlerinden olup tipik bir ışık ağacıdır"},
            new Tree{ID=2,Age=5,Name="Karaçam",Note="Çamgiller familyasından bir çam türü."},
            new Tree{ID=5,Age=3,Name="Titrek kavak",Note=" söğütgiller familyasından 25 m'ye kadar boylanabilen, silindirik gövde, sık dallı, geniş konik tepeye sahip bir kavak türü."},
            new Tree{ID=3,Age=8,Name="İspi meşesi",Note="Kayıngiller familyasından Türkiye'ye özgü endemik meşe alt türü."},
            new Tree{ID=4,Age=2,Name="Macar meşesi",Note="40 m'ye kadar boy yapabilen kalın dallı geniş tepeli büyükçe bir ağaçtır. Gövde kabukları yukarıdan aşağıya doğru çatlaklı haldedir."}

        };

        private readonly ICustomLogger _logger;
        public TreeController(ICustomLogger logger)
        {
            _logger = logger;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Route 
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            var tree = trees.SingleOrDefault(item => item.ID == id);
            if (tree == null)
                return NotFound("Ağaç bulunamadı.");
           
            return Ok(tree);
        }

        [HttpGet("idWithQuery")]
        public IActionResult GetByIdWithQuery([FromQuery] int id) // Query
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            var tree = trees.SingleOrDefault(item => item.ID == id);
            if (tree == null)
                return NotFound("Ağaç bulunamadı.");
            
            return Ok(tree);
        }

        [HttpGet("all")] // Oluşturma sırasına göre sıralamakta
        public IActionResult GetAll()
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            if (trees.Count == 0)
                return NotFound("Ağaçlar bulunamadı.");
            return Ok(trees);
        }

        [HttpPost()]
        public IActionResult Create([FromBody] Tree newTree)
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            var tree = trees.SingleOrDefault(item => item.ID == newTree.ID);
            if (tree is not null)
                return BadRequest("Ağaç mevcuttur.");
            newTree.Name = newTree.Name.FirstLetterToUpper();
            newTree.Note = newTree.Note.FirstLetterToUpper();
            trees.Add(newTree);
            return Created("Ağaç eklendi.", newTree);
        }

        [HttpPatch("editNote/{id}")]
        public IActionResult EditNote(int id, [FromBody] string note)
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            var editTree = trees.Find(item => item.ID == id);
            if (editTree is null)
                return BadRequest("Ağaç bulunamadı.");
            if (note is null)
                return BadRequest("Note değeri boş bırakılamaz.");
            editTree.Note = note != default ? note.FirstLetterToUpper() : editTree.Note;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            var deleteTree = trees.Find(item => item.ID == id);
            if (deleteTree is null)
                return BadRequest("Ağaç bulunamadı.");
            trees.Remove(deleteTree);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Tree tree)
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            var editTree = trees.Find(item => item.ID == id);
            if (editTree is null)
                return BadRequest("Ağaç mevcut değil");
            editTree.Name = tree.Name.FirstLetterToUpper();
            editTree.Age = tree.Age;
            editTree.Note = tree.Note.FirstLetterToUpper();

            return Ok($"{id}'ye sahip film düzenlendi.");
        }

        [HttpGet("sortAscByName")] // isme göre artan sıralama
        public IActionResult SortAscByName()
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            if (trees.Count <= 0)
                return NotFound("Ağaçlar bulunamadı.");
            return Ok(trees.OrderBy(tree => tree.Name));
        }

        [HttpGet("sortDescByName")] // isme göre azalan sıralama
        public IActionResult SortDescByName()
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            if (trees.Count <= 0)
                return NotFound("Ağaçlar bulunamadı.");
            return Ok(trees.OrderByDescending(tree => tree.Name));
        }

        [HttpGet("sortAscByID")] // ID göre artan sıralama
        public IActionResult SortAscByID()
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            if (trees.Count <= 0)
                return NotFound("Ağaçlar bulunamadı.");
            return Ok(trees.OrderBy(tree => tree.ID));
        }

        [HttpGet("sortDescByID")] // ID göre azalan sıralama
        public IActionResult SortDescByID()
        {
            _logger.Write($"{this.Request.Method} metodu başlatıldı.");
            if (trees.Count <= 0)
                return NotFound("Ağaçlar bulunamadı.");
            return Ok(trees.OrderByDescending(tree => tree.ID));
        }
    }
}
