import React, { useState } from 'react';
import styles from './ProductCard.module.css';
import { Card, ConfigProvider, Flex, Badge, Modal } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import ProductCard from './ProductCard';
import { ProductDetail } from '../../pages/ProductDetail/ProductDetail';
import cardImg from "../../../assets/apple.png";

const { Meta } = Card;

const ProductCardTwo: React.FC<{productId: string}> = (productId) => {
  const [isModalOpen, setIsModalOpen] = useState(false);

  const handleAddButtonClick = () => {
      setIsModalOpen(true);
  };
  
  const handleOk = () => {
      setIsModalOpen(false);
      console.log('ok');
  };
  
  const handleCancel = () => {
      setIsModalOpen(false);
      console.log('cancel');
  };
  
  const handleLoading = () => {
      console.log('Loading');
  }

  return (
    <Card
      style={{ width: 280 , border: '1px solid #E5E7EB',}}
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
              src={cardImg}
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
                onClick={handleAddButtonClick}
                className="AddProductButton"
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
                Add
              </button>
              <Modal open={isModalOpen} onOk={handleOk} onCancel={handleCancel} footer={null} width="85%" >
                <ProductDetail productId="1"/>
            </Modal>
              <button
                onClick={handleAddButtonClick}
                className="AddProductButtonIcon"
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

export default ProductCardTwo;