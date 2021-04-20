<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Коммерческие предложения</h6>
          <q-btn :to="'/new-agreement/create?partner=' + $route.params.partnerId" size="sm" color="primary" :icon="icons.mdiPencil" label="новое предложение" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="number" :props="props">
            {{ props.row.number }}
          </q-td>

          <q-td key="from" :props="props">
            {{ props.row.from }}
          </q-td>

          <q-td key="validFrom" :props="props">
            {{ props.row.validFrom }}
          </q-td>

          <q-td key="validTo" :props="props">
            {{ props.row.validTo }}
          </q-td>

          <q-td key="status" :props="props">
            {{ props.row.status }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn-dropdown class="q-mr-sm" size="sm" color="deep-orange" label="Изменить статус">
              <q-list>
                <q-item clickable v-close-popup @click="approve(props.row.businessProposalId)">
                  <q-item-section>
                    <q-item-label title="Утвердить отпраленное коммерческое предложение.">Утвердить</q-item-label>
                  </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="deny(props.row.businessProposalId)">
                  <q-item-section>
                    <q-item-label title="Отклоняет коммерческое предложние, отправленное на утверждение.">Отклонить</q-item-label>
                  </q-item-section>
                </q-item>

                <q-item clickable v-close-popup @click="cancel(props.row.businessProposalId)">
                  <q-item-section>
                    <q-item-label title="Аннулирует действующее коммерческое предложение.">Аннулировать</q-item-label>
                  </q-item-section>
                </q-item>
              </q-list>
            </q-btn-dropdown>
            <q-btn title="Отправить на утверждение контактному лицу партнера коммерческое предложение о реализации товаров или услуг." color="primary" class="q-mr-sm" size="sm" label="Отправить на утверждение" :loading="loading" />
            <q-btn :to="'/new-order/create?businessProposal=' + props.row.businessProposalId" title="Создать заказ на основании коммерческого предложения" class="q-mr-sm" color="purple" size="sm" label="Создать заказ" :loading="loading" />
            <q-btn :to="'/business-proposal/' + props.row.businessProposalId" color="secondary" size="sm" label="Просмотр" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

  </div>
</template>

<script>
import icons from 'src/mixins/icons'
export default {
  name: 'BusinessProposalsTable',
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    }
  },
  methods: {
    saveChanges (partnerId) {
    },
    approve (businessProposalId) {
    },
    deny (businessProposalId) {
    },
    cancel (businessProposalId) {
    }
  },
  data: () => {
    return {
      loading: false,
      createAgreement: false,
      columns: [
        { name: 'number', label: '#', align: 'left', field: 'number' },
        { name: 'from', label: 'От', field: 'from' },
        { name: 'validFrom', label: 'Действут с', field: 'validFrom' },
        { name: 'validTo', label: 'Действует по', field: 'validTo' },
        { name: 'status', label: 'Статус', field: 'status' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
