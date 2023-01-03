using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCacheDemo.Models
{
    public class ParaCust
    {
        public string AParCusId { get; set; }
        public string AClientCode { get; set; }
        public string AParId { get; set; }
        public ParaStatus AStatus { get; set; }
        public string ACreateBy { get; set; }
        public DateTime ACreateDte { get; set; }
        public string AModifieBy { get; set; }
        public DateTime AModifieDte { get; set; }
        public string AActiveBy { get; set; }
        public DateTime AActiveDte { get; set; }
        public string ACancelBy { get; set; }
        public DateTime ACancelDte { get; set; }
        public string ACustType { get; set; }
        public ParaCustState AState { get; set; }
    }

    public enum ParaStatus
    {
        ChoDuyet = 0,
        HieuLuc = 1,
        HetHieuLuc = 2

    }

    public enum ParaCustState
    {
        AnToan = 0,
        VuotCB1 = 1,
        VuotCB2 = 2,
        XuLy = 3,
        DongBangVSD = 4
    }
}
