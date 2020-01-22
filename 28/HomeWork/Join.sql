SELECT d.TypeId,d.Titles,d.Pages,dt.Title,ds.Id,ds.RenderId,ds.ReceiverId,ds.DocumentId,ds.Status,ds.DateTime
FROM Document AS d
 JOIN DocumentType AS dt
        ON d.TypeId = dt.Id
    JOIN DocumentStatus AS ds
        ON ds.DocumentId = d.Id

