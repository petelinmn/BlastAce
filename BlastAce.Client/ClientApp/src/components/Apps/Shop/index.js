import React, { Component } from 'react';
import { ConsentBoard } from '../../../common/ConsentBoard';

const Shop = () => {
  const displayName = Shop.name;

  return (
    <div>
      <ConsentBoard appId={'eshop'} />
    </div>
  )
}

export { Shop };
