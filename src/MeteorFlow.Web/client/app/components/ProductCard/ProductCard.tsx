import React, { useState } from 'react';
import styles from './ProductCard.module.css';
import { PlusOutlined, MinusOutlined } from '@ant-design/icons';
import { Card, ConfigProvider, Badge, Flex } from 'antd';


const { Meta } = Card;

const ProductCard: React.FC = () => {
  const [quantity, setQuantity] = useState<number>(1);

  const handleIncrease = () => {
    setQuantity(quantity + 1);
  };

  const handleDecrease = () => {
    if (quantity > 0) {
      setQuantity(quantity - 1);
    }
  };

  return (
    <Card
      style={{ width: 300 , border: '1px solid #E5E7EB',}}
      cover={
        <div
          style={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
            width: '94%',
            padding: '3%',
            position: 'relative',
          }}
        >
          <Badge.Ribbon text="20%" color="#009F7F" placement="end">
            <img
              alt="example"
              src="https://s3-alpha-sig.figma.com/img/2185/6114/b99ba2815e5662f5c03e58a5c26bdd6e?Expires=1701648000&Signature=kQQQqriCjqtlylS8j~V-ioYKhtPsILYBl3qxJohc5dPOhvaLliyUCOXbMMkZ-aMOWFzraEAwJtByIBp~fC5udJLgajlIgscNhtiFJPEARnm6XZANaFuhJuWTHInlPZAbPDujqJK0atVIanPVXIgu2B5w4Yml7dPJWkuS-FtaW9HO9mwk7Cvx0fMLNVD2UTfGXg~jzq5y7pclvqjtmgcOmk8kbv0yIew1DCxMjnFIoIi1A2~xqFvXqh-GdDwFQ2XI0b8hDP~nmRJmREjbbd-SVS2bOcfye3zL~tB5v24rxGq0jpKC~Ps4jB8Trgd5F71WlFGAWgsSJKDANea5Ih~O3A__&Key-Pair-Id=APKAQ4GOSFWCVNEHN3O4"
              style={{ maxWidth: '100%', maxHeight: '100%', objectFit: 'cover' }}
            />
          </Badge.Ribbon>
        </div>
      }
      actions={[
        <ConfigProvider
          theme={{
            token: {
              colorPrimary: '#009F7F',
            },
          }}
        >
          <Flex
            justify="center"
            style={{ width: '100%' }}
          >
            <div
              style={{
                display: 'flex',
                justifyContent: 'center',
                alignItems: 'center',
                width: '90%',
              }}
            >
              <button
                onClick={handleDecrease}
                style={{
                  backgroundColor: '#E5E7EB',
                  color: '#4B5563',
                  border: 'none',
                  padding: '12px 24px',
                  borderRadius: '0 4px 4px 0',
                  cursor: 'pointer',
                  fontSize: '12px',
                }}
              >
                <MinusOutlined key="minus"/>
              </button>
              <button
                onClick={handleIncrease}
                style={{
                  backgroundColor: '#F3F4F6',
                  color: '#4B5563   ',
                  border: 'none',
                  padding: '12px 24px',
                  borderRadius: '4px 0 0 4px',
                  cursor: 'pointer',
                  fontSize: '12px',
                  width: '100%',
                }}
              >
                <span key="quantity">{quantity}</span>
              </button>
              <button
                onClick={handleIncrease}
                style={{
                  backgroundColor: '#E5E7EB',
                  color: '#4B5563',
                  border: 'none',
                  padding: '12px 24px',
                  borderRadius: '0 4px 4px 0',
                  cursor: 'pointer',
                  fontSize: '12px',
                }}
              >
                <PlusOutlined/>
              </button>
            </div>
          </Flex>
        </ConfigProvider>,
      ]}
    >
      <Meta
        title={
          <>
            <span>$11.60</span> {/* Giá mới */}
            <span
              style={{
                textDecoration: 'line-through',
                color: '#6B7280',
                marginLeft: '5px',
                fontSize: '11px',
              }}
            >
              $15.00 {/* Giá cũ */}
            </span>
          </>
        }
        description="apples"
      />
    </Card>
  );
};

export default ProductCard;