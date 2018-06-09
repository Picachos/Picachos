
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/06/2018 18:48:44
-- Generated from EDMX file: C:\Users\My Hp\Desktop\Versiones Picachos\Picachos 5\Picachos.Backend\Negocio\EntidadesNegocio\PicachosBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [picachos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__convenio__fk_Cli__03275C9C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[convenio] DROP CONSTRAINT [FK__convenio__fk_Cli__03275C9C];
GO
IF OBJECT_ID(N'[ModeloPicachosStoreContainer].[FK__matricula__alu__78F3E6EC]', 'F') IS NOT NULL
    ALTER TABLE [ModeloPicachosStoreContainer].[matricula] DROP CONSTRAINT [FK__matricula__alu__78F3E6EC];
GO
IF OBJECT_ID(N'[ModeloPicachosStoreContainer].[FK__matricula__asi__79E80B25]', 'F') IS NOT NULL
    ALTER TABLE [ModeloPicachosStoreContainer].[matricula] DROP CONSTRAINT [FK__matricula__asi__79E80B25];
GO
IF OBJECT_ID(N'[dbo].[FK__productoU__matPr__21ABE3BC]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productoUnionmateriaprima] DROP CONSTRAINT [FK__productoU__matPr__21ABE3BC];
GO
IF OBJECT_ID(N'[dbo].[FK__productoU__pedID__294D0584]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productoUnionPedido] DROP CONSTRAINT [FK__productoU__pedID__294D0584];
GO
IF OBJECT_ID(N'[dbo].[FK__productoU__prodT__20B7BF83]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productoUnionmateriaprima] DROP CONSTRAINT [FK__productoU__prodT__20B7BF83];
GO
IF OBJECT_ID(N'[dbo].[FK__productoU__prodT__24885067]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productoUnionventa] DROP CONSTRAINT [FK__productoU__prodT__24885067];
GO
IF OBJECT_ID(N'[dbo].[FK__productoU__prodT__2858E14B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productoUnionPedido] DROP CONSTRAINT [FK__productoU__prodT__2858E14B];
GO
IF OBJECT_ID(N'[dbo].[FK__productoU__ventI__257C74A0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[productoUnionventa] DROP CONSTRAINT [FK__productoU__ventI__257C74A0];
GO
IF OBJECT_ID(N'[dbo].[fk_agendaNot]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[notaDeVenta] DROP CONSTRAINT [fk_agendaNot];
GO
IF OBJECT_ID(N'[dbo].[fk_AgendaSped]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[pedido] DROP CONSTRAINT [fk_AgendaSped];
GO
IF OBJECT_ID(N'[dbo].[fk_ClientePrestEq]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[prestamoEquipo] DROP CONSTRAINT [fk_ClientePrestEq];
GO
IF OBJECT_ID(N'[dbo].[fk_ClienteSped]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[pedido] DROP CONSTRAINT [fk_ClienteSped];
GO
IF OBJECT_ID(N'[dbo].[fk_CorteDeDiapag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[pago] DROP CONSTRAINT [fk_CorteDeDiapag];
GO
IF OBJECT_ID(N'[dbo].[fk_CorteDediaSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[salidaDeEfectivo] DROP CONSTRAINT [fk_CorteDediaSale];
GO
IF OBJECT_ID(N'[dbo].[fk_DeudaNot]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[notaDeVenta] DROP CONSTRAINT [fk_DeudaNot];
GO
IF OBJECT_ID(N'[dbo].[fk_Deudapag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[pago] DROP CONSTRAINT [fk_Deudapag];
GO
IF OBJECT_ID(N'[dbo].[fk_Materiaprima]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[entradasalidaMateriaprima] DROP CONSTRAINT [fk_Materiaprima];
GO
IF OBJECT_ID(N'[dbo].[fk_PrestamoEquipoE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[equipo] DROP CONSTRAINT [fk_PrestamoEquipoE];
GO
IF OBJECT_ID(N'[dbo].[fk_VentaCort]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[corteDeDia] DROP CONSTRAINT [fk_VentaCort];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[agenda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[agenda];
GO
IF OBJECT_ID(N'[dbo].[alumno]', 'U') IS NOT NULL
    DROP TABLE [dbo].[alumno];
GO
IF OBJECT_ID(N'[dbo].[asignatura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[asignatura];
GO
IF OBJECT_ID(N'[dbo].[cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cliente];
GO
IF OBJECT_ID(N'[dbo].[convenio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[convenio];
GO
IF OBJECT_ID(N'[dbo].[corteDeDia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[corteDeDia];
GO
IF OBJECT_ID(N'[dbo].[deuda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[deuda];
GO
IF OBJECT_ID(N'[dbo].[entradasalidaMateriaprima]', 'U') IS NOT NULL
    DROP TABLE [dbo].[entradasalidaMateriaprima];
GO
IF OBJECT_ID(N'[dbo].[equipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[equipo];
GO
IF OBJECT_ID(N'[dbo].[materiaPrima]', 'U') IS NOT NULL
    DROP TABLE [dbo].[materiaPrima];
GO
IF OBJECT_ID(N'[ModeloPicachosStoreContainer].[matricula]', 'U') IS NOT NULL
    DROP TABLE [ModeloPicachosStoreContainer].[matricula];
GO
IF OBJECT_ID(N'[dbo].[notaDeVenta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[notaDeVenta];
GO
IF OBJECT_ID(N'[dbo].[pago]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pago];
GO
IF OBJECT_ID(N'[dbo].[pedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[pedido];
GO
IF OBJECT_ID(N'[dbo].[prestamoEquipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[prestamoEquipo];
GO
IF OBJECT_ID(N'[dbo].[productoTerminado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productoTerminado];
GO
IF OBJECT_ID(N'[dbo].[productoUnionmateriaprima]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productoUnionmateriaprima];
GO
IF OBJECT_ID(N'[dbo].[productoUnionPedido]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productoUnionPedido];
GO
IF OBJECT_ID(N'[dbo].[productoUnionventa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[productoUnionventa];
GO
IF OBJECT_ID(N'[dbo].[salidaDeEfectivo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[salidaDeEfectivo];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[usuario];
GO
IF OBJECT_ID(N'[dbo].[venta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[venta];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'agenda'
CREATE TABLE [dbo].[agenda] (
    [agendaID] int IDENTITY(1,1) NOT NULL,
    [fechaEntrega] datetime  NULL
);
GO

-- Creating table 'alumnoes'
CREATE TABLE [dbo].[alumnoes] (
    [dni] int  NOT NULL,
    [nombre] nvarchar(50)  NULL
);
GO

-- Creating table 'asignaturas'
CREATE TABLE [dbo].[asignaturas] (
    [cod] nvarchar(5)  NOT NULL,
    [cuat] int  NULL
);
GO

-- Creating table 'clientes'
CREATE TABLE [dbo].[clientes] (
    [clienteID] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(50)  NULL,
    [rfc] nvarchar(50)  NULL,
    [observaciones] nvarchar(50)  NULL,
    [direccion] nvarchar(50)  NULL,
    [telefono] nvarchar(50)  NULL
);
GO

-- Creating table 'convenios'
CREATE TABLE [dbo].[convenios] (
    [convenioID] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(50)  NULL,
    [fecha] datetime  NULL,
    [formato] nvarchar(50)  NULL,
    [fk_ClienteIDcon] int  NULL
);
GO

-- Creating table 'corteDeDias'
CREATE TABLE [dbo].[corteDeDias] (
    [corteID] int IDENTITY(1,1) NOT NULL,
    [ventaID] int  NULL,
    [fecha] datetime  NULL,
    [total] float  NULL,
    [lecturaInicial] nvarchar(50)  NULL,
    [lecturaFinal] nvarchar(50)  NULL
);
GO

-- Creating table 'deudas'
CREATE TABLE [dbo].[deudas] (
    [deudaID] int IDENTITY(1,1) NOT NULL,
    [sumatoriatotal] float  NULL,
    [montotal] float  NULL
);
GO

-- Creating table 'entradasalidaMateriaprimas'
CREATE TABLE [dbo].[entradasalidaMateriaprimas] (
    [EntSalID] int IDENTITY(1,1) NOT NULL,
    [materiaPrimaID] int  NULL,
    [observacion] nvarchar(150)  NULL,
    [fecha] datetime  NULL,
    [cantidadES] int  NULL
);
GO

-- Creating table 'equipoes'
CREATE TABLE [dbo].[equipoes] (
    [equipoID] int IDENTITY(1,1) NOT NULL,
    [prestamoEquipoID] int  NULL,
    [nombre] nvarchar(50)  NULL,
    [descripcion] nvarchar(50)  NULL,
    [ultimaFechaDeMantenimiento] datetime  NULL,
    [estatus] nvarchar(50)  NULL
);
GO

-- Creating table 'materiaPrimas'
CREATE TABLE [dbo].[materiaPrimas] (
    [materiaPrimaID] int IDENTITY(1,1) NOT NULL,
    [productoID] int  NULL,
    [nombreMateria] nvarchar(150)  NULL,
    [existencia] int  NULL,
    [descripcion] nvarchar(150)  NULL
);
GO

-- Creating table 'notaDeVentas'
CREATE TABLE [dbo].[notaDeVentas] (
    [notaDeVentaID] int IDENTITY(1,1) NOT NULL,
    [deudaID] int  NULL,
    [agendaID] int  NULL,
    [fecha] datetime  NULL
);
GO

-- Creating table 'pagoes'
CREATE TABLE [dbo].[pagoes] (
    [pagoID] int IDENTITY(1,1) NOT NULL,
    [corteID] int  NULL,
    [fecha] datetime  NULL,
    [monto] float  NULL,
    [deudaID] int  NULL
);
GO

-- Creating table 'pedidoes'
CREATE TABLE [dbo].[pedidoes] (
    [pedidoID] int IDENTITY(1,1) NOT NULL,
    [fechaDeEntrega] datetime  NULL,
    [clienteID] int  NULL,
    [agendaID] int  NULL
);
GO

-- Creating table 'prestamoEquipoes'
CREATE TABLE [dbo].[prestamoEquipoes] (
    [prestamoEquipoID] int IDENTITY(1,1) NOT NULL,
    [clienteID] int  NULL
);
GO

-- Creating table 'productoTerminadoes'
CREATE TABLE [dbo].[productoTerminadoes] (
    [productoID] int IDENTITY(1,1) NOT NULL,
    [ventaID] int  NULL,
    [pedidoID] int  NULL,
    [nombreProducto] nvarchar(50)  NULL,
    [existencia] int  NULL,
    [tipo] varchar(50)  NULL
);
GO

-- Creating table 'salidaDeEfectivoes'
CREATE TABLE [dbo].[salidaDeEfectivoes] (
    [salidaID] int IDENTITY(1,1) NOT NULL,
    [corteID] int  NULL,
    [monto] float  NULL,
    [fecha] datetime  NULL,
    [descripcion] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'usuarios'
CREATE TABLE [dbo].[usuarios] (
    [usuarioID] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(50)  NULL,
    [nombreUsuario] nvarchar(50)  NULL,
    [contrasena] nvarchar(50)  NULL,
    [rol] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ventas'
CREATE TABLE [dbo].[ventas] (
    [ventaID] int IDENTITY(1,1) NOT NULL,
    [venta1] int  NULL,
    [cantidad] int  NULL,
    [total] float  NULL
);
GO

-- Creating table 'matricula'
CREATE TABLE [dbo].[matricula] (
    [alumnoes_dni] int  NOT NULL,
    [asignaturas_cod] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'productoUnionmateriaprima'
CREATE TABLE [dbo].[productoUnionmateriaprima] (
    [materiaPrimas_materiaPrimaID] int  NOT NULL,
    [productoTerminadoes_productoID] int  NOT NULL
);
GO

-- Creating table 'productoUnionPedido'
CREATE TABLE [dbo].[productoUnionPedido] (
    [pedidoes_pedidoID] int  NOT NULL,
    [productoTerminadoes_productoID] int  NOT NULL
);
GO

-- Creating table 'productoUnionventa'
CREATE TABLE [dbo].[productoUnionventa] (
    [productoTerminadoes_productoID] int  NOT NULL,
    [ventas_ventaID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [agendaID] in table 'agenda'
ALTER TABLE [dbo].[agenda]
ADD CONSTRAINT [PK_agenda]
    PRIMARY KEY CLUSTERED ([agendaID] ASC);
GO

-- Creating primary key on [dni] in table 'alumnoes'
ALTER TABLE [dbo].[alumnoes]
ADD CONSTRAINT [PK_alumnoes]
    PRIMARY KEY CLUSTERED ([dni] ASC);
GO

-- Creating primary key on [cod] in table 'asignaturas'
ALTER TABLE [dbo].[asignaturas]
ADD CONSTRAINT [PK_asignaturas]
    PRIMARY KEY CLUSTERED ([cod] ASC);
GO

-- Creating primary key on [clienteID] in table 'clientes'
ALTER TABLE [dbo].[clientes]
ADD CONSTRAINT [PK_clientes]
    PRIMARY KEY CLUSTERED ([clienteID] ASC);
GO

-- Creating primary key on [convenioID] in table 'convenios'
ALTER TABLE [dbo].[convenios]
ADD CONSTRAINT [PK_convenios]
    PRIMARY KEY CLUSTERED ([convenioID] ASC);
GO

-- Creating primary key on [corteID] in table 'corteDeDias'
ALTER TABLE [dbo].[corteDeDias]
ADD CONSTRAINT [PK_corteDeDias]
    PRIMARY KEY CLUSTERED ([corteID] ASC);
GO

-- Creating primary key on [deudaID] in table 'deudas'
ALTER TABLE [dbo].[deudas]
ADD CONSTRAINT [PK_deudas]
    PRIMARY KEY CLUSTERED ([deudaID] ASC);
GO

-- Creating primary key on [EntSalID] in table 'entradasalidaMateriaprimas'
ALTER TABLE [dbo].[entradasalidaMateriaprimas]
ADD CONSTRAINT [PK_entradasalidaMateriaprimas]
    PRIMARY KEY CLUSTERED ([EntSalID] ASC);
GO

-- Creating primary key on [equipoID] in table 'equipoes'
ALTER TABLE [dbo].[equipoes]
ADD CONSTRAINT [PK_equipoes]
    PRIMARY KEY CLUSTERED ([equipoID] ASC);
GO

-- Creating primary key on [materiaPrimaID] in table 'materiaPrimas'
ALTER TABLE [dbo].[materiaPrimas]
ADD CONSTRAINT [PK_materiaPrimas]
    PRIMARY KEY CLUSTERED ([materiaPrimaID] ASC);
GO

-- Creating primary key on [notaDeVentaID] in table 'notaDeVentas'
ALTER TABLE [dbo].[notaDeVentas]
ADD CONSTRAINT [PK_notaDeVentas]
    PRIMARY KEY CLUSTERED ([notaDeVentaID] ASC);
GO

-- Creating primary key on [pagoID] in table 'pagoes'
ALTER TABLE [dbo].[pagoes]
ADD CONSTRAINT [PK_pagoes]
    PRIMARY KEY CLUSTERED ([pagoID] ASC);
GO

-- Creating primary key on [pedidoID] in table 'pedidoes'
ALTER TABLE [dbo].[pedidoes]
ADD CONSTRAINT [PK_pedidoes]
    PRIMARY KEY CLUSTERED ([pedidoID] ASC);
GO

-- Creating primary key on [prestamoEquipoID] in table 'prestamoEquipoes'
ALTER TABLE [dbo].[prestamoEquipoes]
ADD CONSTRAINT [PK_prestamoEquipoes]
    PRIMARY KEY CLUSTERED ([prestamoEquipoID] ASC);
GO

-- Creating primary key on [productoID] in table 'productoTerminadoes'
ALTER TABLE [dbo].[productoTerminadoes]
ADD CONSTRAINT [PK_productoTerminadoes]
    PRIMARY KEY CLUSTERED ([productoID] ASC);
GO

-- Creating primary key on [salidaID] in table 'salidaDeEfectivoes'
ALTER TABLE [dbo].[salidaDeEfectivoes]
ADD CONSTRAINT [PK_salidaDeEfectivoes]
    PRIMARY KEY CLUSTERED ([salidaID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [usuarioID] in table 'usuarios'
ALTER TABLE [dbo].[usuarios]
ADD CONSTRAINT [PK_usuarios]
    PRIMARY KEY CLUSTERED ([usuarioID] ASC);
GO

-- Creating primary key on [ventaID] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [PK_ventas]
    PRIMARY KEY CLUSTERED ([ventaID] ASC);
GO

-- Creating primary key on [alumnoes_dni], [asignaturas_cod] in table 'matricula'
ALTER TABLE [dbo].[matricula]
ADD CONSTRAINT [PK_matricula]
    PRIMARY KEY NONCLUSTERED ([alumnoes_dni], [asignaturas_cod] ASC);
GO

-- Creating primary key on [materiaPrimas_materiaPrimaID], [productoTerminadoes_productoID] in table 'productoUnionmateriaprima'
ALTER TABLE [dbo].[productoUnionmateriaprima]
ADD CONSTRAINT [PK_productoUnionmateriaprima]
    PRIMARY KEY NONCLUSTERED ([materiaPrimas_materiaPrimaID], [productoTerminadoes_productoID] ASC);
GO

-- Creating primary key on [pedidoes_pedidoID], [productoTerminadoes_productoID] in table 'productoUnionPedido'
ALTER TABLE [dbo].[productoUnionPedido]
ADD CONSTRAINT [PK_productoUnionPedido]
    PRIMARY KEY NONCLUSTERED ([pedidoes_pedidoID], [productoTerminadoes_productoID] ASC);
GO

-- Creating primary key on [productoTerminadoes_productoID], [ventas_ventaID] in table 'productoUnionventa'
ALTER TABLE [dbo].[productoUnionventa]
ADD CONSTRAINT [PK_productoUnionventa]
    PRIMARY KEY NONCLUSTERED ([productoTerminadoes_productoID], [ventas_ventaID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [agendaID] in table 'notaDeVentas'
ALTER TABLE [dbo].[notaDeVentas]
ADD CONSTRAINT [fk_agendaNot]
    FOREIGN KEY ([agendaID])
    REFERENCES [dbo].[agenda]
        ([agendaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_agendaNot'
CREATE INDEX [IX_fk_agendaNot]
ON [dbo].[notaDeVentas]
    ([agendaID]);
GO

-- Creating foreign key on [agendaID] in table 'pedidoes'
ALTER TABLE [dbo].[pedidoes]
ADD CONSTRAINT [fk_AgendaSped]
    FOREIGN KEY ([agendaID])
    REFERENCES [dbo].[agenda]
        ([agendaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_AgendaSped'
CREATE INDEX [IX_fk_AgendaSped]
ON [dbo].[pedidoes]
    ([agendaID]);
GO

-- Creating foreign key on [fk_ClienteIDcon] in table 'convenios'
ALTER TABLE [dbo].[convenios]
ADD CONSTRAINT [FK__convenio__fk_Cli__03275C9C]
    FOREIGN KEY ([fk_ClienteIDcon])
    REFERENCES [dbo].[clientes]
        ([clienteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK__convenio__fk_Cli__03275C9C'
CREATE INDEX [IX_FK__convenio__fk_Cli__03275C9C]
ON [dbo].[convenios]
    ([fk_ClienteIDcon]);
GO

-- Creating foreign key on [clienteID] in table 'prestamoEquipoes'
ALTER TABLE [dbo].[prestamoEquipoes]
ADD CONSTRAINT [fk_ClientePrestEq]
    FOREIGN KEY ([clienteID])
    REFERENCES [dbo].[clientes]
        ([clienteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_ClientePrestEq'
CREATE INDEX [IX_fk_ClientePrestEq]
ON [dbo].[prestamoEquipoes]
    ([clienteID]);
GO

-- Creating foreign key on [clienteID] in table 'pedidoes'
ALTER TABLE [dbo].[pedidoes]
ADD CONSTRAINT [fk_ClienteSped]
    FOREIGN KEY ([clienteID])
    REFERENCES [dbo].[clientes]
        ([clienteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_ClienteSped'
CREATE INDEX [IX_fk_ClienteSped]
ON [dbo].[pedidoes]
    ([clienteID]);
GO

-- Creating foreign key on [corteID] in table 'pagoes'
ALTER TABLE [dbo].[pagoes]
ADD CONSTRAINT [fk_CorteDeDiapag]
    FOREIGN KEY ([corteID])
    REFERENCES [dbo].[corteDeDias]
        ([corteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_CorteDeDiapag'
CREATE INDEX [IX_fk_CorteDeDiapag]
ON [dbo].[pagoes]
    ([corteID]);
GO

-- Creating foreign key on [corteID] in table 'salidaDeEfectivoes'
ALTER TABLE [dbo].[salidaDeEfectivoes]
ADD CONSTRAINT [fk_CorteDediaSale]
    FOREIGN KEY ([corteID])
    REFERENCES [dbo].[corteDeDias]
        ([corteID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_CorteDediaSale'
CREATE INDEX [IX_fk_CorteDediaSale]
ON [dbo].[salidaDeEfectivoes]
    ([corteID]);
GO

-- Creating foreign key on [ventaID] in table 'corteDeDias'
ALTER TABLE [dbo].[corteDeDias]
ADD CONSTRAINT [fk_VentaCort]
    FOREIGN KEY ([ventaID])
    REFERENCES [dbo].[ventas]
        ([ventaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_VentaCort'
CREATE INDEX [IX_fk_VentaCort]
ON [dbo].[corteDeDias]
    ([ventaID]);
GO

-- Creating foreign key on [deudaID] in table 'notaDeVentas'
ALTER TABLE [dbo].[notaDeVentas]
ADD CONSTRAINT [fk_DeudaNot]
    FOREIGN KEY ([deudaID])
    REFERENCES [dbo].[deudas]
        ([deudaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_DeudaNot'
CREATE INDEX [IX_fk_DeudaNot]
ON [dbo].[notaDeVentas]
    ([deudaID]);
GO

-- Creating foreign key on [deudaID] in table 'pagoes'
ALTER TABLE [dbo].[pagoes]
ADD CONSTRAINT [fk_Deudapag]
    FOREIGN KEY ([deudaID])
    REFERENCES [dbo].[deudas]
        ([deudaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_Deudapag'
CREATE INDEX [IX_fk_Deudapag]
ON [dbo].[pagoes]
    ([deudaID]);
GO

-- Creating foreign key on [materiaPrimaID] in table 'entradasalidaMateriaprimas'
ALTER TABLE [dbo].[entradasalidaMateriaprimas]
ADD CONSTRAINT [fk_Materiaprima]
    FOREIGN KEY ([materiaPrimaID])
    REFERENCES [dbo].[materiaPrimas]
        ([materiaPrimaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_Materiaprima'
CREATE INDEX [IX_fk_Materiaprima]
ON [dbo].[entradasalidaMateriaprimas]
    ([materiaPrimaID]);
GO

-- Creating foreign key on [prestamoEquipoID] in table 'equipoes'
ALTER TABLE [dbo].[equipoes]
ADD CONSTRAINT [fk_PrestamoEquipoE]
    FOREIGN KEY ([prestamoEquipoID])
    REFERENCES [dbo].[prestamoEquipoes]
        ([prestamoEquipoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'fk_PrestamoEquipoE'
CREATE INDEX [IX_fk_PrestamoEquipoE]
ON [dbo].[equipoes]
    ([prestamoEquipoID]);
GO

-- Creating foreign key on [alumnoes_dni] in table 'matricula'
ALTER TABLE [dbo].[matricula]
ADD CONSTRAINT [FK_matricula_alumno]
    FOREIGN KEY ([alumnoes_dni])
    REFERENCES [dbo].[alumnoes]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [asignaturas_cod] in table 'matricula'
ALTER TABLE [dbo].[matricula]
ADD CONSTRAINT [FK_matricula_asignatura]
    FOREIGN KEY ([asignaturas_cod])
    REFERENCES [dbo].[asignaturas]
        ([cod])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_matricula_asignatura'
CREATE INDEX [IX_FK_matricula_asignatura]
ON [dbo].[matricula]
    ([asignaturas_cod]);
GO

-- Creating foreign key on [materiaPrimas_materiaPrimaID] in table 'productoUnionmateriaprima'
ALTER TABLE [dbo].[productoUnionmateriaprima]
ADD CONSTRAINT [FK_productoUnionmateriaprima_materiaPrima]
    FOREIGN KEY ([materiaPrimas_materiaPrimaID])
    REFERENCES [dbo].[materiaPrimas]
        ([materiaPrimaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [productoTerminadoes_productoID] in table 'productoUnionmateriaprima'
ALTER TABLE [dbo].[productoUnionmateriaprima]
ADD CONSTRAINT [FK_productoUnionmateriaprima_productoTerminado]
    FOREIGN KEY ([productoTerminadoes_productoID])
    REFERENCES [dbo].[productoTerminadoes]
        ([productoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productoUnionmateriaprima_productoTerminado'
CREATE INDEX [IX_FK_productoUnionmateriaprima_productoTerminado]
ON [dbo].[productoUnionmateriaprima]
    ([productoTerminadoes_productoID]);
GO

-- Creating foreign key on [pedidoes_pedidoID] in table 'productoUnionPedido'
ALTER TABLE [dbo].[productoUnionPedido]
ADD CONSTRAINT [FK_productoUnionPedido_pedido]
    FOREIGN KEY ([pedidoes_pedidoID])
    REFERENCES [dbo].[pedidoes]
        ([pedidoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [productoTerminadoes_productoID] in table 'productoUnionPedido'
ALTER TABLE [dbo].[productoUnionPedido]
ADD CONSTRAINT [FK_productoUnionPedido_productoTerminado]
    FOREIGN KEY ([productoTerminadoes_productoID])
    REFERENCES [dbo].[productoTerminadoes]
        ([productoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productoUnionPedido_productoTerminado'
CREATE INDEX [IX_FK_productoUnionPedido_productoTerminado]
ON [dbo].[productoUnionPedido]
    ([productoTerminadoes_productoID]);
GO

-- Creating foreign key on [productoTerminadoes_productoID] in table 'productoUnionventa'
ALTER TABLE [dbo].[productoUnionventa]
ADD CONSTRAINT [FK_productoUnionventa_productoTerminado]
    FOREIGN KEY ([productoTerminadoes_productoID])
    REFERENCES [dbo].[productoTerminadoes]
        ([productoID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ventas_ventaID] in table 'productoUnionventa'
ALTER TABLE [dbo].[productoUnionventa]
ADD CONSTRAINT [FK_productoUnionventa_venta]
    FOREIGN KEY ([ventas_ventaID])
    REFERENCES [dbo].[ventas]
        ([ventaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_productoUnionventa_venta'
CREATE INDEX [IX_FK_productoUnionventa_venta]
ON [dbo].[productoUnionventa]
    ([ventas_ventaID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------