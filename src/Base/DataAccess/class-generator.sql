SELECT b.RDB$FIELD_NAME AS COLUMNNAME, d.RDB$TYPE_NAME, d.RDB$TYPE AS COLUMNTYPE,
       c.RDB$FIELD_LENGTH, b.RDB$NULL_FLAG,
       case d.RDB$TYPE
            when 7 then 'short' -- SMALLINT
            when 8 then 'int'   -- INTEGER   
            when 10 then 'double'   -- FLOAT
            when 12 then 'DateTime' -- DATE
            when 13 then 'TimeSpan' -- TIME
            when 14 then 'string' -- CHAR
            when 16 then 'long' -- BIGINT
            when 27 then 'double'   -- DOUBLE PRECISION
            when 35 then 'long' -- TIMESTAMP
            when 37 then 'string'   -- VARCHAR
            else 'UNKNOWN_' + d.RDB$TYPE_NAME
        end as COLUMNTYPE,
        case
            when b.RDB$NULL_FLAG IS null and d.RDB$TYPE IN (7,8,10,16,27,35)
            then '?'
            else ''
        end NullableSign
FROM   RDB$RELATIONS a
INNER JOIN RDB$RELATION_FIELDS b
ON     a.RDB$RELATION_NAME = b.RDB$RELATION_NAME
INNER JOIN RDB$FIELDS c
ON     b.RDB$FIELD_SOURCE = c.RDB$FIELD_NAME
INNER JOIN RDB$TYPES d
ON     c.RDB$FIELD_TYPE = d.RDB$TYPE
WHERE  a.RDB$SYSTEM_FLAG = 0 AND  d.RDB$FIELD_NAME = 'RDB$FIELD_TYPE' AND b.RDB$RELATION_NAME='UNIT_GROUPS'
ORDER BY a.RDB$RELATION_NAME, b.RDB$FIELD_ID