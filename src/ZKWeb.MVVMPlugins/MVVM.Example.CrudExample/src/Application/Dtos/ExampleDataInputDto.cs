﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ZKWeb.MVVMPlugins.MVVM.Common.Base.src.Application.Dtos;

namespace ZKWeb.MVVMPlugins.MVVM.Example.CrudExample.src.Application.Dtos
{
    [Description("示例数据的传入信息")]
    public class ExampleDataInputDto : IInputDto
    {
        [Description("数据Id")]
        public Guid Id { get; set; }
        [Description("数据名称"), Required]
        public string Name { get; set; }
        [Description("数据描述")]
        public string Description { get; set; }
    }
}
