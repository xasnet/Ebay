SELECT o.order_id
     , o.created_at
     , cl.first_name
     , cl.second_name
     , cl.last_name
     , cl.birthdate
     , SUM(pr.price * oi.quantity) OVER(PARTITION BY o.order_id) AS total_amount
     , pr.product_name
     , pr.price
     , oi.quantity
     , o.shipping_address
     , o.shipping_date
     FROM public.orders      AS o
LEFT JOIN public.order_items AS oi ON oi.order_id    = o.order_id
LEFT JOIN public.products    AS pr ON pr.product_id  = oi.product_id
LEFT JOIN public.customers   AS cl ON cl.customer_id = o.customer_id
WHERE pr.product_id IS NOT NULL