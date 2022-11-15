-- Table: public.order_items

-- DROP TABLE IF EXISTS public.order_items;

CREATE TABLE IF NOT EXISTS public.order_items
(
    order_id integer NOT NULL,
    product_id integer NOT NULL,
    quantity integer,
    created_at timestamp without time zone NOT NULL DEFAULT now(),
    CONSTRAINT "FK_product" FOREIGN KEY (product_id)
        REFERENCES public.products (product_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_order" FOREIGN KEY (order_id)
        REFERENCES public.orders (order_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.order_items
    OWNER to postgres;

COMMENT ON TABLE public.order_items
    IS 'Состав заказов';

COMMENT ON COLUMN public.order_items.order_id
    IS 'Идентификатор заказа. Внешний ключ';

COMMENT ON COLUMN public.order_items.product_id
    IS 'Идентификатор продукта. Внешний ключ';

COMMENT ON COLUMN public.order_items.quantity
    IS 'Количество';

COMMENT ON COLUMN public.order_items.created_at
    IS 'Время создания записи в таблице';


INSERT INTO public.order_items(order_id, product_id, quantity)
VALUES                        (1       , 1         , 14      ),
                              (1       , 2         , 13      ),
                              (2       , 3         , 12      ),
                              (3       , 4         , 11      );

--
