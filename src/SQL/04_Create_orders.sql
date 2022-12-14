-- Table: public.orders

-- DROP TABLE IF EXISTS public.orders;

CREATE TABLE IF NOT EXISTS public.orders
(
    order_id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    customer_id integer NOT NULL,
    shipping_address text COLLATE pg_catalog."default" NOT NULL,
    shipping_date date NOT NULL,
    created_at timestamp without time zone NOT NULL DEFAULT now(),
    CONSTRAINT "PK_order" PRIMARY KEY (order_id),
    CONSTRAINT "FK_customer" FOREIGN KEY (customer_id)
        REFERENCES public.customers (customer_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.orders
    OWNER to postgres;

COMMENT ON TABLE public.orders
    IS 'Список заказов';

COMMENT ON COLUMN public.orders.order_id
    IS 'Идентификатор заказа. Первичный ключ';

COMMENT ON COLUMN public.orders.customer_id
    IS 'Идентификатор покупателя. Внешний ключ';

COMMENT ON COLUMN public.orders.shipping_address
    IS 'Адрес доставки заказа';

COMMENT ON COLUMN public.orders.shipping_date
    IS 'Дата доставки';

COMMENT ON COLUMN public.orders.created_at
    IS 'Время создания записи в таблице';

INSERT INTO public.orders(customer_id, shipping_address, shipping_date)
VALUES                   ( 1         , 'г.Москва'      , '2022-12-01'),
                         ( 2         , 'г.Самара'      , '2022-12-02'),
                         ( 3         , 'г.Саратов'     , '2022-12-03'),
                         ( 3         , 'г.Энгельс'     , '2022-12-04'),
                         ( 4         , 'г.Омск'        , '2022-12-05');

--
