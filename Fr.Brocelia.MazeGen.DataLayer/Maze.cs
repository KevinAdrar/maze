//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fr.Brocelia.MazeGen.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Maze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Maze()
        {
            this.MazeTile = new HashSet<MazeTile>();
        }
    
        public int Id { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int Entree { get; set; }
        public int Sortie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MazeTile> MazeTile { get; set; }
    }
}
