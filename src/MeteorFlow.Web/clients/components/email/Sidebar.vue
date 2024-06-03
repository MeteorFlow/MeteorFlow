<template>
  <div class="w-64 bg-gray-800 text-white p-4">
    <ul>
      <li class="mb-4"><router-link to="/" class="hover:underline">Inbox</router-link></li>
      <li class="mb-4"><router-link to="/sent" class="hover:underline">Sent</router-link></li>
      <li class="mb-4"><router-link to="/drafts" class="hover:underline">Drafts</router-link></li>
      <li><router-link to="/trash" class="hover:underline">Trash</router-link></li>
    </ul>
  </div>
</template>